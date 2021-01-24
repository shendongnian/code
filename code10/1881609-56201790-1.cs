    using Microsoft.Azure.Cosmos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using VidlyAsp.DataHandlers;
    
    namespace VidlyAsp.DataHandlers
    {
        public class PersistenceNew
        {
    
            private static string _endpointUri;
            private static string _primaryKey;
            private CosmosClient cosmosClient;
    
            private CosmosDatabase database;
            private CosmosContainer movieContainer;
            private CosmosContainer genreContainer;
            private string containerId;
            private string _databaseId;
    
    
            public PersistenceNew(Uri endpointUri, string primaryKey)
            {
                _databaseId = "Vidly";
                _endpointUri = endpointUri.ToString();
                _primaryKey = primaryKey;
                this.GetStartedAsync();
            }
            public async Task GetStartedAsync()
            {
                // Create a new instance of the Cosmos Client
                this.cosmosClient = new CosmosClient(_endpointUri, _primaryKey);
                database = await cosmosClient.Databases.CreateDatabaseIfNotExistsAsync(_databaseId);
                CosmosContainer moviesContainer = await GetOrCreateContainerAsync(database, "movies");
                CosmosContainer genresContainer = await GetOrCreateContainerAsync(database, "genres");
                movieContainer = moviesContainer;
                genreContainer = genresContainer;
            }
    
            public async Task<GenresModel> GetGenre(string id)
            {
                
                var sqlQueryText = ("SELECT * FROM c WHERE c._id = {0}", id).ToString();
                var partitionKeyValue = id;
    
                CosmosSqlQueryDefinition queryDefinition = new CosmosSqlQueryDefinition(sqlQueryText);
    
    
                CosmosResultSetIterator<GenresModel> queryResultSetIterator = this.genreContainer.Items.CreateItemQuery<GenresModel>(queryDefinition, partitionKeyValue);
    
                List<GenresModel> genres = new List<GenresModel>();
    
                while (queryResultSetIterator.HasMoreResults)
                {
                    CosmosQueryResponse<GenresModel> currentResultSet = await queryResultSetIterator.FetchNextSetAsync();
                    foreach (GenresModel genre in currentResultSet)
                    {
                        genres.Add(genre);
    
                    }
                }
                return genres.FirstOrDefault();
            }
    
            public async Task<MoviesModel> GetMovie(string id)
            {
    
                var sqlQueryText = "SELECT * FROM c WHERE c._id = '" + id + "'";
                var partitionKeyValue = id;
    
                CosmosSqlQueryDefinition queryDefinition = new CosmosSqlQueryDefinition(sqlQueryText);
    
    
                CosmosResultSetIterator<MoviesModel> queryResultSetIterator = this.movieContainer.Items.CreateItemQuery<MoviesModel>(queryDefinition, partitionKeyValue);
    
                List<MoviesModel> movies = new List<MoviesModel>();
    
                while (queryResultSetIterator.HasMoreResults)
                {
                    CosmosQueryResponse<MoviesModel> currentResultSet = await queryResultSetIterator.FetchNextSetAsync();
                    foreach (MoviesModel movie in currentResultSet)
                    {
                        movies.Add(movie);
    
                    }
                }
                return movies.FirstOrDefault();
            }
    
            /*
        Run a query (using Azure Cosmos DB SQL syntax) against the container
    */
            public async Task<List<MoviesModel>> GetAllMovies()
            {
                List<MoviesModel> movies = new List<MoviesModel>();
    
                // SQL
                CosmosResultSetIterator<MoviesModel> setIterator = movieContainer.Items.GetItemIterator<MoviesModel>(maxItemCount: 1);
                while (setIterator.HasMoreResults)
                {
                    foreach (MoviesModel item in await setIterator.FetchNextSetAsync())
                    {
                       movies.Add(item);
                    }
                }
    
                return movies;
            }
    
            public async Task<List<GenresModel>> GetAllGenres()
            {
                List<GenresModel> genres = new List<GenresModel>();
    
                // SQL
                CosmosResultSetIterator<GenresModel> setIterator = genreContainer.Items.GetItemIterator<GenresModel>(maxItemCount: 1);
                while (setIterator.HasMoreResults)
                {
                    foreach (GenresModel item in await setIterator.FetchNextSetAsync())
                    {
                        genres.Add(item);
                    }
                }
    
                return genres;
            }
    
            private static async Task<CosmosContainer> GetOrCreateContainerAsync(CosmosDatabase database, string containerId)
            {
                CosmosContainerSettings containerDefinition = new CosmosContainerSettings(id: containerId, partitionKeyPath: "/_id");
    
                return await database.Containers.CreateContainerIfNotExistsAsync(
                    containerSettings: containerDefinition,
                    throughput: 400);
            }
        }
    }
