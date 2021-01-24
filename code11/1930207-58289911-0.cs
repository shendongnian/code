    [SuppressMessage("Reason", "Whatever the id is", Justification="Do Not Remove <T> Variables, its required even though the compiler notes its not required")]
    public virtual async Task<bool> Delete(int id)
    {
        var entity = LoadById(id);
        using (IDbConnection cn = new SqlConnection(_conn))
        {
            cn.Open();
            var result = await cn.DeleteAsync<T>(entity);
            return result;
        }
    }
