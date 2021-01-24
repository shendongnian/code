csharp
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace StackOverflow
{
    public class Program
    {
        public enum NodeType
        {
            Start = 1,
            End = 2
        }
        public class Node
        {
            public ObjectId Id { get; set; }
            public NodeType Type { get; set; }
        }
        private async static Task Main(string[] args)
        {
            var _database = new MongoClient("mongodb://localhost").GetDatabase("test");
            await GetCollection<Node>().InsertOneAsync(new Node { Type = NodeType.Start });
            IMongoCollection<T> GetCollection<T>() where T : class
            {
                return _database.GetCollection<T>(typeof(T).Name);
            }
            IMongoQueryable<TModel> Get<TModel>() where TModel : class
            {
                return GetCollection<TModel>().AsQueryable();
            }
            async Task<TModel> FindOneAsync<TModel>(Expression<Func<TModel, bool>> predicate) where TModel : class
            {
                var foundEntity = await Get<TModel>().FirstOrDefaultAsync(predicate);
                if (foundEntity == null)
                {
                    throw new Exception("not found");
                }
                return foundEntity;
            }
            var res = await FindOneAsync<Node>(node => node.Type == NodeType.Start);
        }
    }
}
