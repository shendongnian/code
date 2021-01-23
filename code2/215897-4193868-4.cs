    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
      {
        throw new ArgumentNullException("info");
      }
      info.AddValue("Version", this.m_version);
      info.AddValue("Comparer", this.m_comparer, typeof(IEqualityComparer<T>));
      info.AddValue("Capacity", (this.m_buckets == null) ? 0 : this.m_buckets.Length);
      if (this.m_buckets != null)
      {
        T[] array = new T[this.m_count];
        this.CopyTo(array);
        info.AddValue("Elements", array, typeof(T[]));
      }
    }
