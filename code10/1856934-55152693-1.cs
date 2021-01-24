using System;
					
public class Entity {}
public class AccountEntity : Entity {}
public class CustomAccountEntity : AccountEntity {}
public interface IQueryable<in T>
	where T : Entity
{}
public interface IRepository<in T>
	where T : Entity
{
    void Save(T record);
}
public class EntityRepository<T> : IRepository<T>
	where T : Entity
{
    public void Save(T record) {}
}
public class Program
{
	public static void Main()
	{
		// This is ***VALID***:
		IRepository<CustomAccountEntity> repo = new EntityRepository<AccountEntity>();
		Console.WriteLine(repo == null ? "cast is invalid" : "cast is valid");
	}
}
https://dotnetfiddle.net/cnEdcm
So whenever you need a `IRepository<CustomAccountEntity>`, you can use a concrete  `EntityRepository<AccountEntity>` instance. Seems counter-intuitive, but it's actually totally right: If the concrete method is `Save(AccountEntity)`, it can obviously handle `CustomAccountEntity` instances too; OTOH if the concrete method were `Save(CustomAccountEntity)`, it would NOT be able to handle simple `AccountEntity` instances.
Having said that, then I think you should
1. Use contravariance instead;
2. Declare all dependencies using the most specialised type, e.g. `IRepository<CustomWhateverEntity>`;
3. In the IoC registration code, for each particular entity, setup either `Repository<CustomeWhateverEntity>`, if you need the extra behaviour, or just `Repository<WhateverEntity>` otherwise.
