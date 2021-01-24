    using System.Linq;
    ...
    protected void Sort() {
      m_Items = m_Items
        .OrderBy(item => item.TransactionDate)
        .ToList(); // Assuming m_Items is List<T>
    }
