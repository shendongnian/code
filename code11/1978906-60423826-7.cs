    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var item = new InformationTreeItem("ROOT")
                {
                    Children =
                    {
                        new InformationTreeItem("Level 1")
                        {
                            DeviceInformation =
                            {
                                new DeviceInformation("Device 1/1"),
                                new DeviceInformation("Device 1/2")
                            },
                            MeasurementInformation =
                            {
                                new MeasurementInformation("Measure 1/1"),
                                new MeasurementInformation("Measure 1/2")
                            },
                            Children =
                            {
                                new InformationTreeItem("Level 2")
                                {
                                    DeviceInformation =
                                    {
                                        new DeviceInformation("Device 2/1"),
                                        new DeviceInformation("Device 2/2")
                                    },
                                    MeasurementInformation =
                                    {
                                        new MeasurementInformation("Measure 2/1"),
                                        new MeasurementInformation("Measure 2/2")
                                    },
                                    Children =
                                    {
                                        new InformationTreeItem("Level 3")
                                    }
                                }
                            }
                        }
                    }
                };
    
                DataContext = item;
            }
        }
    
        public interface IInformation
        {
            string Description { get; }
        }
    
        public class InformationTreeItem : IEnumerable<IInformation>, IInformation
        {
            public InformationTreeItem(string description)
            {
                Description = description;
            }
    
            private InformationTreeItem(string description, IList<IInformation> children)
            {
                Description = description;
                Children = children;
            }
    
            public IList<IInformation> Children { get; } = new List<IInformation>();
    
            public IList<DeviceInformation> DeviceInformation { get; } = new List<DeviceInformation>();
    
            public IList<MeasurementInformation> MeasurementInformation { get; } = new List<MeasurementInformation>();
    
            public string Description { get; }
    
            public IEnumerator<IInformation> GetEnumerator()
            {
                var list = new List<IInformation>();
    
                if (DeviceInformation.Any())
                {
                    list.Add(new InformationTreeItem(nameof(DeviceInformation), new List<IInformation>(DeviceInformation)));
                }
    
                if (MeasurementInformation.Any())
                {
                    list.Add(new InformationTreeItem(nameof(MeasurementInformation), new List<IInformation>(MeasurementInformation)));
                }
    
                foreach (var child in Children)
                {
                    list.Add(child);
                }
    
                return list.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            public override string ToString()
            {
                return Description;
            }
        }
    
        public class DeviceInformation : IInformation
        {
            public DeviceInformation(string description)
            {
                Description = description;
            }
    
            public string Description { get; }
    
            public override string ToString()
            {
                return Description;
            }
        }
    
        public class MeasurementInformation : IInformation
        {
            public MeasurementInformation(string description)
            {
                Description = description;
            }
    
            public string Description { get; }
    
            public override string ToString()
            {
                return Description;
            }
        }
    }
