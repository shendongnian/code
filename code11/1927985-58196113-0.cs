    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Dynamic;
    private void Test()
    {
      // Initialize test data
      var items = new List<Person>();
      items.Add(new Person { Surname = "Surname 1", DateOfBirth = new DateTime(2019, 09, 02) });
      items.Add(new Person { Surname = "Surname 2", DateOfBirth = new DateTime(2019, 09, 02) });
      items.Add(new Person { Surname = "Surname 3", DateOfBirth = new DateTime(2019, 09, 03) });
      items.Add(new Person { Surname = "Surname 4", DateOfBirth = new DateTime(2019, 09, 04) });
      // Create test query
      var query = items.Where(item => item.DateOfBirth == new DateTime(2019, 09, 02));
      var RetrieveProperties = new List<string> { "Surname", "DateOfBirth" };
      var results = new List<ExpandoObject>();
      if ( RetrieveProperties.Count != 0 )
        foreach ( var item in query )
        {
          dynamic result = new ExpandoObject();
          var resultInterface = (IDictionary<string, object>)result;
          foreach ( var propertyName in RetrieveProperties )
          {
            var property = item.GetType().GetProperty(propertyName);
            if ( property != null )
              resultInterface[property.Name] = property.GetValue(item);
          }
          results.Add(result);
        }
      // Providing results in the datagrid
      DataGridViewTest.Rows.Clear();
      DataGridViewTest.Columns.Clear();
      int count = results.Count();
      if ( count > 0 )
      {
        foreach ( var property in results[0] )
          DataGridViewTest.Columns.Add(property.Key, property.Key);
        for ( int indexRow = 0; indexRow < count; indexRow++ )
        {
          DataGridViewTest.Rows.Add();
          int indexValue = 0;
          foreach ( var property in results[indexRow] )
            DataGridViewTest.Rows[indexRow].Cells[indexValue++].Value = property.Value.ToString();
        }
      }
    }
