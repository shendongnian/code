csharp
async Task Update(CreateOrEditAccomplishmentsDto input)
{
    var context = _dbContextProvider.GetDbContext(Abp.MultiTenancy.MultiTenancySides.Host);
    context.Entry(ObjectMapper.Map(input, _accomplishmentRepository.GetAll().Where(a => a.Id == input.Id.Value).Include(a => a.Categories).FirstOrDefault())).State = EntityState.Modified;
    await context.SaveChangesAsync();
}
Technically, the `context.Entry(...).State = EntityState.Modified` part of that line is redundant, but I'm not sure as to the implementation of anything you have provided, so I'm accounting for the context not actually tracking the returned object from the call to `Map`.
If you are getting an exception due to the context already tracking an entity with the same value for `id`, then **remove** the following line.
csharp
context.Entry(ObjectMapper.Map(input, _accomplishmentRepository.GetAll().Where(a => a.Id == input.Id.Value).Include(a => a.Categories).FirstOrDefault())).State = EntityState.Modified;
Afterwards, add the following line in it's place before the call to `SaveChangesAsync`.
chsarp
ObjectMapper.Map(input, _accomplishmentRepository.GetAll().Where(a => a.Id == input.Id.Value).Include(a => a.Categories).FirstOrDefault());
