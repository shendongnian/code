var result = db.Set(a).OrderBy(orderByString).ToListAsync();
combo.DataSource = result.Result;
but my suggestion would be pass a generic class/entity
public static void BindComboboxByEntity<T>(ComboBox combo, string displayMember, string valueMember, string orderBy) where T : class
{
   if (combo is ComboBox)
        using (var db = new MyDbContext())
        {
            combo.ValueMember = valueMember;
            combo.DisplayMember = displayMember;
            combo.DataSource = db.Set<T>().OrderBy(orderBy);
        }
   
}
then pass it as
BindComboboxByEntity<MyEntity>(MyCombo, "name", "id", "name");
