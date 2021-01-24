    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfApp7
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private MyViewModel m_MyViewModel;
            public MainWindow()
            {
                
                InitializeComponent();
                m_MyViewModel = new MyViewModel();
                myGrid.DataContext = MyVM;
            }
    
            public MyViewModel MyVM
            {
                get
                {
                    return m_MyViewModel;
                }
            }
        }
    
        public class MyViewModel : ViewModelBase
        {
            public List<string> MyCollection
            {
                get
                {
                    return new List<string> { "A", "B", "C" };
                }
            }
    
            private bool isListViewItemSelected;
    
            public bool IsListViewItemSelected
            {
                get
                {
                    return isListViewItemSelected;
                }
                set
                {
                    isListViewItemSelected = value;
                    RaisePropertyChanged("IsListViewItemSelected");
                }
            }
    
    
            private string selectedItem;
    
            public string SelectedItem
            {
                get { return selectedItem; }
                set
                {
                    if (value != selectedItem)
                    {
                        selectedItem = value;
                        if (selectedItem == null)
                        {
                            IsListViewItemSelected = false;
                        }
                        else
                        {
                            IsListViewItemSelected = true;
                        }
                        RaisePropertyChanged("SelectedItem");
                        RaisePropertyChanged("SelectedTxtString");
                    }
                }
            }
    
            public string SelectedTxtString
            {
                get
                {
                    //return SelectedItem;
                    return "\"" + SelectedItem + "\" is selected!";
                }
            }
        }
    
        public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
        {
    
            #region DisplayName
    
            /// <summary>
            /// Returns the user-friendly name of this object.
            /// Child classes can set this property to a new value,
            /// or override it to determine the value on-demand.
            /// </summary>
            public virtual string DisplayName { get; protected set; }
    
            #endregion // DisplayName
    
            #region Debugging Aides
    
            /// <summary>
            /// Warns the developer if this object does not have
            /// a public property with the specified name. This 
            /// method does not exist in a Release build.
            /// </summary>
            [Conditional("DEBUG")]
            [DebuggerStepThrough]
            public void VerifyPropertyName(string propertyName)
            {
                // Verify that the property name matches a real,  
                // public, instance property on this object.
                if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                {
                    string msg = "Invalid property name: " + propertyName;
    
                    if (this.ThrowOnInvalidPropertyName)
                        throw new Exception(msg);
                    else
                        Debug.Fail(msg);
                }
            }
    
            /// <summary>
            /// Returns whether an exception is thrown, or if a Debug.Fail() is used
            /// when an invalid property name is passed to the VerifyPropertyName method.
            /// The default value is false, but subclasses used by unit tests might 
            /// override this property's getter to return true.
            /// </summary>
            protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
    
            #endregion // Debugging Aides
    
            #region INotifyPropertyChanged Members
    
            /// <summary>
            /// Raised when a property on this object has a new value.
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;
    
            /// <summary>
            /// Raises this object's PropertyChanged event.
            /// </summary>
            /// <param name="propertyName">The property that has a new value.</param>
            protected virtual void RaisePropertyChanged(string propertyName)
            {
                VerifyPropertyName(propertyName);
    
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    var e = new PropertyChangedEventArgs(propertyName);
                    handler(this, e);
                }
            }
    
            #endregion // INotifyPropertyChanged Members
    
    
            #region IDisposable Members
    
            /// <summary>
            /// Invoked when this object is being removed from the application
            /// and will be subject to garbage collection.
            /// </summary>
            public void Dispose()
            {
                this.OnDispose();
            }
    
            /// <summary>
            /// Child classes can override this method to perform 
            /// clean-up logic, such as removing event handlers.
            /// </summary>
            protected virtual void OnDispose()
            {
            }
    
            #endregion // IDisposable Members
    
        }
    }
