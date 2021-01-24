    public class WorkItemAttribute : Attribute, ITestDataSource {
        private readonly int workItemId;
        public WorkItemAttribute(int workItemId) {
            this.workItemId = workItemId;
        }
        public IEnumerable<object[]> GetData(MethodInfo methodInfo) {
            var table = GetTableItemsFromTestCase(workItemId);            
            yield return new object[] { dataTable };
        }
        private DataTable GetTableItemsFromTestCase(int workItemId) {
            //Return the data table items from TFS
        }
        public string GetDisplayName(MethodInfo methodInfo, object[] data) {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "{0} WorkItem {1} - ({2})", methodInfo.Name, workItemId, string.Join(",", data));
            return null;
        }
    }
