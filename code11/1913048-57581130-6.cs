    public class FilterModel {
        public int Page { get; set; }
        public int Limit { get; set; }
        public string ColumnName { get; set; }
        public string Term { get; set; }
        public FilterModel() {
            this.Page = 1;
            this.Limit = 3;
        }
        public object Clone() {
            var jsonString = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject(jsonString, this.GetType());
        }
    }
