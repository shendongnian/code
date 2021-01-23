    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.ComponentModel;
    using System.Collections.Generic;
    
    namespace RadioButtonSample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                
                //Initialize the first group of radio buttons and add them to the panel.
                foreach (object obj in Enum.GetValues(typeof(ChoicesEnum)))
                {
                    RadioButton rb = new RadioButton() { Content = obj, };
                    sp.Children.Add(rb);
                    rb.Checked += new RoutedEventHandler(rb_Checked);
                    rb.Unchecked += new RoutedEventHandler(rb_Unchecked);
                }
            }
    
            void rb_Unchecked(object sender, RoutedEventArgs e)
            {
                Console.Write((sender as RadioButton).Content.ToString() + " checked.");
            }
    
            void rb_Checked(object sender, RoutedEventArgs e)
            {
                Console.Write((sender as RadioButton).Content.ToString() + " unchecked.");
            }
    
            private void showChoice_Click(object sender, RoutedEventArgs e)
            {
                foreach (RadioButton rb in sp.Children)
                {
                    if (rb.IsChecked == true)
                    {
                        MessageBox.Show(rb.Content.ToString());
                        break;
                    }
                }
            }
    
            private void showChoice2_Click(object sender, RoutedEventArgs e)
            {
                //Show selected choice in the ViewModel.
                ChoiceVM selected = (sp2.DataContext as ViewModel).SelectedChoiceVM;
                if (selected != null)
                    MessageBox.Show(selected.Choice.ToString());
            }
        }
    
        //Test Enum
        public enum ChoicesEnum
        {
            Choice1,
            Choice2,
            Choice3,
        }
    
        //ViewModel for a single Choice
        public class ChoiceVM : INotifyPropertyChanged
        {
            public ChoicesEnum Choice { get; private set; }
            public ChoiceVM(ChoicesEnum choice)
            {
                this.Choice = choice;
            }
    
            private bool isChecked;
            public bool IsChecked
            {
                get { return this.isChecked; }
                set
                {
                    this.isChecked = value;
                    this.OnPropertyChanged("IsChecked");
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
    
            #endregion
    
        }
    
        //Sample ViewModel containing a list of choices
        //and exposes a property showing the currently selected choice
        public class ViewModel : INotifyPropertyChanged
        {
            public List<ChoiceVM> Choices { get; private set; }
            public ViewModel()
            {
                this.Choices = new List<ChoiceVM>();
                //wrap each choice in a ChoiceVM and add it to the list.
                foreach (var choice in Enum.GetValues(typeof(ChoicesEnum)))
                    this.Choices.Add(new ChoiceVM((ChoicesEnum)choice));
            }
    
            public ChoiceVM SelectedChoiceVM
            {
                get
                {
                    ChoiceVM selectedChoice = this.Choices.FirstOrDefault((c) => c.IsChecked == true);
                    return selectedChoice;
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
    
            #endregion
    
        }
    }
