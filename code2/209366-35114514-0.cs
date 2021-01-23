    void CopyProperties(object src, object dest) {
      foreach (var source in src.GetType().GetProperties().Where(p => p.CanRead)) {
        var prop = dest.GetType().GetProperty(source.Name);
        if (prop?.CanWrite == true)
          prop.SetValue(this, source.GetValue(src, null), null);
      }
    }
