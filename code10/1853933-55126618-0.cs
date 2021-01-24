    using Nito.AsyncEx;
    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace MyApp.Global
    {
        public interface IMyGlobalDataService
        {
            Task<List<ImportantDataItem>> GetFilteredDataOfMyList(string prop1);
            Task LoadMyImportantDataListAsync();
        }
        public class MyGlobalDataService : IMyGlobalDataService
        {
            private MyDbContext _myDbContext;
            private readonly AsyncReaderWriterLock myImportantDataLock = new AsyncReaderWriterLock();
            private List<ImportantDataItem> myImportantDataList { get; set; }
            public async Task<List<ImportantDataItem>> GetFilteredDataOfMyList(string prop1)
            {
                List<ImportantDataItem> list;
                using (await myImportantDataLock.ReaderLockAsync())
                {
                    list = myImportantDataList.Where(itm => itm.Prop1 == prop1).ToList();
                }
                return list;
            }
            public async Task LoadMyImportantDataListAsync()
            {
                // this method gets called when the Service is created and once every hour thereafter
                using (await myImportantDataLock.WriterLockAsync())
                {
                    this.MyImportantDataList = await _myDbContext.ImportantDataItems.ToListAsync();
                }
                
                return;
            }
            public MyGlobalDataService(MyDbContext myDbContext)
            {
                _myDbContext = myDbContext;
            };
        }
    }
