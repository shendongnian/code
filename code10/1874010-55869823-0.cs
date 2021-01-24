public static IQueryable<ContextClass> SelectAsContext(this IQueryable<Entity1> queryable)
{
  return queryable.Select(x => new ContextClass
  {
    Prop1 = x.Prop1,
    Prop2 = x.Prop2.Prop
  });
}
So in the calling code:
var contexts = await queryable.SelectAsContext().ToListAsync();
The idea of the constructor was so I didn't have to cast it every single time I want the context. Using this extension method also serves the same purpose since the logic is still encapsulated.
