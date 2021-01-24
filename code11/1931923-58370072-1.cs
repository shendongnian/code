    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using MongoDB.Entities;
    using MongoDB.Entities.Common;
    using MongoDB.Driver.Linq;
    using MongoDB.Driver;
    namespace StackOverflow
    {
        public class Person : Entity
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
        public static class Program
        {
            public async static Task Main()
            {
                new DB("test");
                await (new Person { Name = "Person", Age = 22 }).SaveAsync();
                var result =
                    await GetAllAsync<Person, object>(
                        p => p.Age,
                        true,
                        p => new Person { Name = p.Name, Age = p.Age });
            }
            public static async Task<ICollection<TEntity>> GetAllAsync<TEntity, TOrderBy>
                (
                Expression<Func<TEntity, TOrderBy>> orderBy,
                bool isDescendingOrder = false,
                Expression<Func<TEntity, TEntity>> projection = null,
                CancellationToken cancellationToken = default
                ) 
            {
                var query = DB.Queryable<TEntity>();
                var sortedQuery = isDescendingOrder ?
                                    query.OrderByDescending(orderBy) :
                                    query.OrderBy(orderBy);
                if (projection != null)
                {
                    query = sortedQuery.Select(projection);
                }
                return await query.ToListAsync(cancellationToken) as ICollection<TEntity>;
            }
        }
    }
