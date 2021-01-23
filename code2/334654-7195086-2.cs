    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    /// <summary>
    /// The main form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The checked list box property helper.
        /// </summary>
        private CheckedListBoxPropertyHelper<MyItem> helper;
        /// <summary>
        /// My object to bind to the checked list box.
        /// </summary>
        private MyItem myObjectDataSource;
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            this.myObjectDataSource = new MyItem();
            this.helper = new CheckedListBoxPropertyHelper<MyItem>(this.checkedListBox1, this.myObjectDataSource, true);
            this.helper.AddCheckListBoxItem(new CheckedPropertyItem("Property One", "Property1"));
            this.helper.AddCheckListBoxItem(new CheckedPropertyItem("Property Two", "Property2"));
            this.helper.AddCheckListBoxItem(new CheckedPropertyItem("Property Three", "Property3"));
        }
        /// <summary>
        /// Handles the Click event of the Button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button1_Click(object sender, EventArgs e)
        {
            // In the constructor
            // if we instantiated: this.helper = new CheckedListBoxPropertyHelper<MyItem>(this.checkedListBox1, this.myObjectDataSource, true);
            // as: this.helper = new CheckedListBoxPropertyHelper<MyItem>(this.checkedListBox1, this.myObjectDataSource, false);
            // changing the last bindImmediate property to false, the changes to the checkboxes wouldn't take effect immediately
            // on the underlying object, you need to call this.helper.CommitChanges() at which point the changes
            // will be made to the datasource object.
           
            // this.helper.CommitChanges();
            Console.WriteLine(this.myObjectDataSource.Property1.ToString());
            Console.WriteLine(this.myObjectDataSource.Property2.ToString());
            Console.WriteLine(this.myObjectDataSource.Property3.ToString());
        }
    }
    /// <summary>
    /// My item.
    /// </summary>
    public class MyItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MyItem"/> is property1.
        /// </summary>
        /// <value><c>true</c> if property1; otherwise, <c>false</c>.</value>
        public bool Property1
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MyItem"/> is property2.
        /// </summary>
        /// <value><c>true</c> if property2; otherwise, <c>false</c>.</value>
        public bool Property2
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MyItem"/> is property3.
        /// </summary>
        /// <value><c>true</c> if property3; otherwise, <c>false</c>.</value>
        public bool Property3
        {
            get;
            set;
        }
    }
    /// <summary>
    /// The checked list box property helper. This binds datasource properties to checkedlistbox items.
    /// </summary>
    public class CheckedListBoxPropertyHelper<T> where T : class
    {
        /// <summary>
        /// The checked list box.
        /// </summary>
        private CheckedListBox checkedListBox;
        /// <summary>
        /// The property info.
        /// </summary>
        private PropertyInfo[] PropertyInfo;
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedListBoxPropertyHelper"/> class.
        /// </summary>
        /// <param name="checkedListBox">The checked list box.</param>
        /// <param name="dataSource">The data source.</param>
        /// <param name="bindImmediate">if set to <c>true</c> [bind immediate].</param>
        public CheckedListBoxPropertyHelper(CheckedListBox checkedListBox, T dataSource, bool bindImmediate)
        {
            this.checkedListBox = checkedListBox;
            this.DataSource = dataSource;
            this.PropertyInfo = this.DataSource.GetType().GetProperties();
            this.BindImmediate = bindImmediate;
            this.checkedListBox.ItemCheck += new ItemCheckEventHandler(CheckedListBox_ItemCheck);
        }
        /// <summary>
        /// The data source.
        /// </summary>
        public T DataSource
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether to [bind immediately] to the datasource object.
        /// </summary>
        /// <value><c>true</c> if [bind immediately]; otherwise, <c>false</c>.</value>
        public bool BindImmediate
        {
            get;
            set;
        }
        /// <summary>
        /// Commits the changes.
        /// </summary>
        public void CommitChanges()
        {
            if (!this.BindImmediate)
            {
                for (int i = 0; i < this.checkedListBox.Items.Count; i++)
                {
                    CheckedPropertyItem checkedItem = this.checkedListBox.Items[i] as CheckedPropertyItem;
                    this.SetChecked(this.checkedListBox.GetItemChecked(i), checkedItem);
                }
            }
            else
            {
                throw new InvalidOperationException("You cannot commit changes when bind immediate is on.");
            }
        }
        /// <summary>
        /// Adds the check list box item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void AddCheckListBoxItem(CheckedPropertyItem item)
        {
            PropertyInfo info = this.GetPropertyInfo(item.PropertyName);
            bool isChecked = false;
            if (info != null)
            {
                isChecked = (bool)info.GetValue(this.DataSource, null);
            }
            this.checkedListBox.Items.Add(item, isChecked);
        }
        /// <summary>
        /// Handles the ItemCheck event of the CheckedListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.ItemCheckEventArgs"/> instance containing the event data.</param>
        private void CheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (BindImmediate)
            {
                CheckedListBox clb = sender as CheckedListBox;
                CheckedPropertyItem checkedItem = clb.Items[e.Index] as CheckedPropertyItem;
                this.SetChecked(
                    e.NewValue == CheckState.Checked ? true : false,
                     checkedItem);
            }
        }
        /// <summary>
        /// Sets the checked.
        /// </summary>
        /// <param name="isChecked">if set to <c>true</c> [is checked].</param>
        /// <param name="clb">The CLB.</param>
        private void SetChecked(bool isChecked, CheckedPropertyItem item)
        {
            PropertyInfo info = this.GetPropertyInfo(item.PropertyName);
            if (info.CanWrite)
            {
                info.SetValue(this.DataSource, isChecked, null);
            }
        }
        /// <summary>
        /// Gets the property info.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        private PropertyInfo GetPropertyInfo(string propertyName)
        {
            return this.PropertyInfo
                .Where(c => c.Name == propertyName)
                .SingleOrDefault();
        }
    }
    /// <summary>
    /// Checked Property Item binding.
    /// </summary>
    public class CheckedPropertyItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedPropertyItem"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="propertyName">Name of the property.</param>
        public CheckedPropertyItem(string title, string propertyName)
        {
            this.Title = title;
            this.PropertyName = propertyName;
        }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string PropertyName
        {
            get;
            private set;
        }
        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return this.Title;
        }
    }
