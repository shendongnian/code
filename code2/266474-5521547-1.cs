    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows;
    using System.Collections;
    
    namespace WpfApplication1
    {
        public class CollectionHelper : Control
        {
            public static DependencyProperty CollectionProperty = DependencyProperty.Register(
                "Collection",
                typeof(IEnumerable),
                typeof(CollectionHelper),
                new FrameworkPropertyMetadata(OnCollectionChanged));
    
            public IEnumerable Collection
            {
                get { return GetValue(CollectionProperty) as IEnumerable; }
                set { SetValue(CollectionProperty, value); }
            }
    
            private static void OnCollectionChanged(object rawSender, DependencyPropertyChangedEventArgs args)
            {
                CollectionHelper sender = (CollectionHelper)rawSender;
                IEnumerable value = args.NewValue as IEnumerable;
                if(value==null)
                {
                    sender.First = null;
                    sender.Last = null;
                    return;
                }
                bool isFirstSet = false;
                object lastItemTemp = null;
                foreach (var item in value)
                {
                    if (!isFirstSet)
                    {
                        sender.First = item;
                        isFirstSet = true;
                    }
                    lastItemTemp = item;
                }
                if (!isFirstSet)
                    sender.First = null;
                sender.Last = lastItemTemp;
            }
    
            public DependencyProperty FirstProperty = DependencyProperty.Register(
                "First",
                typeof(object),
                typeof(CollectionHelper));
    
            public object First
            {
                get { return GetValue(FirstProperty); }
                set { SetValue(FirstProperty, value); }
            }
    
            public DependencyProperty LastProperty = DependencyProperty.Register(
                "Last",
                typeof(object),
                typeof(CollectionHelper));
    
            public object Last
            {
                get { return GetValue(LastProperty); }
                set { SetValue(LastProperty, value); }
            }
        }
    }
