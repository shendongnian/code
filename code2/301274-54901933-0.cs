    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    
    namespace Clipboard
    {
        class Program
        {
            static void Main(string[] args)
            {                                    
                Execute(() =>
                {
                    var backup = Backup();
                    System.Windows.Forms.Clipboard.SetText("text"); //just to change clipboard
                    Restore(backup);
                });                
            }
    
            private static void Execute(Action action)
            {
                var thread = new Thread(() => action());
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
                thread.Join();
            }
    
            private static List<ClipboardItem> Backup()
            {
                var backup = new List<ClipboardItem>();
                var data = System.Windows.Forms.Clipboard.GetDataObject();
                System.Windows.Forms.Clipboard.SetDataObject(data, copy: true); //This seems to be needed to be able to serialize data later.
                data = System.Windows.Forms.Clipboard.GetDataObject();
                var formats = data.GetFormats(false).ToList();
                formats.ForEach(f =>
                {
                    if (data.GetData(f, false) != null && !(data.GetData(f, false) is Stream))
                    {                    
                        backup.Add(new ClipboardItem()
                        {
                            Format = f,
                            ObjectType = data.GetData(f, false).GetType(),
                            ObjectJson = JsonConvert.SerializeObject(data.GetData(f, false))
                        });
                    }                
                });            
                return backup;
            }
    
            private static void Restore(List<ClipboardItem> backup)
            {
                var data = new System.Windows.Forms.DataObject();
                backup.ForEach(item =>
                {               
                    data.SetData(item.Format, JsonConvert.DeserializeObject(item.ObjectJson, item.ObjectType));
                });
                System.Windows.Forms.Clipboard.SetDataObject(data, copy: true);
            }
        }    
    
        public class ClipboardItem
        {
            public string Format { get; set; }
            public Type ObjectType { get; set; }
            public string ObjectJson { get; set; }
        }
    }
