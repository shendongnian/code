      public class BarListConverter : DefaultTypeConverter
      {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
          var list = new List<Bar>();
          if (text == null) return list;
          do
          {
            var barIndex = list.Count + 1;
            var bar = new Bar
            {
              BarID = row.GetField<int>($"BarID_{barIndex}"),
              BarProperty1 = row.GetField<string>($"BarProperty1_{barIndex}"),
              BarProperty2 = row.GetField<string>($"BarProperty2_{barIndex}"),
              BarProperty3 = row.GetField<string>($"BarProperty3_{barIndex}")
            };
            list.Add(bar);
          } while (row.Context.CurrentIndex > 0 && row.Context.CurrentIndex < row.Context.Record.Length - 1);
          return list;
        }
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
          var bars = value as List<Bar>;
          if (bars == null) return null;
          foreach (var bar in bars)
          {
            row.WriteField(bar.BarID);
            row.WriteField(bar.BarProperty1);
            row.WriteField(bar.BarProperty2);
            row.WriteField(bar.BarProperty3);
          }
          return null;
        }
      }
    }
