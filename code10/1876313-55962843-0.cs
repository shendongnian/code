C#
public class UsernameMap : ComponentMap<Username>
{
	public UsernameMap()
	{
		Map(x => x.Value).Access.CamelCaseField(Prefix.Underscore);
	}
}
public class AccountMap : ClassMap<Account>
{
	public AccountMap()
	{
		//Use Component instead of Map for all Username mappings
		Component(x => x.Username);
	}
}
  [1]: https://github.com/FluentNHibernate/fluent-nhibernate/wiki/Fluent-mapping#components
