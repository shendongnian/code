c#
public T GetByCode<T>(string code) where T:IHaveCode
{
      return _context.Set<T>().FirstOrDefault(t => t.Code.Trim().ToLower() == code.Trim().ToLower());
}
