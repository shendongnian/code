    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace My.Web.UI.WebControls
    {
        /// <summary>
        /// Extends the Repeater to be compatable with a DataPager
        /// </summary>
        /// <remarks>
        /// To page through data in a control that implements the IPageableItemContainer interface, DataPager control can be used. 
        /// Repeater does not support paging and does not implement IPageableItemContainer interface. ListView is the only control that works with DataPager. 
        /// 
        /// The DataPager control supports built-in paging user interface (UI). NumericPagerField object enables users to select a page of data by page number.
        /// NextPreviousPagerField object enables users to move through pages of data one page at a time, or to jump to the first or last page of data. 
        /// The size of the pages of data is set by using the PageSize property of the DataPager control. One or more pager field objects can be used in 
        /// a single DataPager control. Custom paging UI can be created by using the TemplatePagerField object. In the TemplatePagerField template, 
        /// the DataPager control is referenced by using the Container property which provides access to the properties of the DataPager control. 
        /// These properties include the starting row index, the page size, and the total number of rows currently bound to the control. 
        /// </remarks>
        [ToolboxData("<my:DataPagerRepeater runat=server></my:DataPagerRepeater>")]
        [Themeable(true)]
        public class DataPagerRepeater : Repeater, IPageableItemContainer
        {
            /// <summary>Gets the maximum number of items to display on a single page of the <see cref="T:InteriorHealth.Web.UI.WebControls.DataPagerRepeater" /> control.
            /// </summary>
            /// <returns>The maximum number of items to display on a single page of the <see cref="T:InteriorHealth.Web.UI.WebControls.DataPagerRepeater" /> control. 
            /// </returns>
            public int MaximumRows
            {
                get;
                //{
                //    return ViewState["maxrows"] != null ? (int)ViewState["maxrows"] : -1;
                //}
                private set;
                //{
                //    ViewState["maxrows"] = value;
                //}
            }
    
            /// <summary>Gets the index of the first record that is displayed on a page of data in the <see cref="T:InteriorHealth.Web.UI.WebControls.DataPagerRepeater" /> control.
            /// </summary>
            /// <returns>The index of the first record that is displayed on a page of data in the <see cref="T:InteriorHealth.Web.UI.WebControls.DataPagerRepeater" /> control.
            /// </returns>
            public int StartRowIndex
            {
                get;
                //{
                //    return ViewState["startrowindex"] != null ? (int)ViewState["startrowindex"] : -1;
                //}
                private set;
                //{
                //    ViewState["startrowindex"] = value;
                //}
            }
    
            /// <summary>
            /// Total number of rows that are avialable, regardless of what is currently being displayed
            /// </summary>
            private int TotalRowsAvailable
            {
                get;
                //{
                //    return ViewState["totalrows"] != null ? (int)ViewState["totalrows"] : -1;
                //}
                set;
                //{
                //    ViewState["totalrows"] = value;
                //}
            }
            
            private static readonly object EventPagePropertiesChanged = new object();
            /// <summary>Occurs when the page properties change, after the <see cref="T:InteriorHealth.Web.UI.WebControls.DataPagerRepeater" /> control sets the new values.
            /// </summary>
            public event EventHandler PagePropertiesChanged
            {
                add
                {
                    base.Events.AddHandler(DataPagerRepeater.EventPagePropertiesChanged, value);
                }
                remove
                {
                    base.Events.RemoveHandler(DataPagerRepeater.EventPagePropertiesChanged, value);
                }
            }
    
            private static readonly object EventPagePropertiesChanging = new object();
            /// <summary>Occurs when the page properties change, but before the <see cref="T:InteriorHealth.Web.UI.WebControls.DataPagerRepeater" /> control sets the new values.
            /// </summary>
            public event EventHandler<PagePropertiesChangingEventArgs> PagePropertiesChanging
            {
                add
                {
                    base.Events.AddHandler(DataPagerRepeater.EventPagePropertiesChanging, value);
                }
                remove
                {
                    base.Events.RemoveHandler(DataPagerRepeater.EventPagePropertiesChanging, value);
                }
            }
    
            private static readonly object EventTotalRowCountAvailable = new object();
            /// <summary>For a description of this member, see <see cref="E:System.Web.UI.WebControls.IPageableItemContainer.TotalRowCountAvailable" />.
            /// </summary>
            public event EventHandler<PageEventArgs> TotalRowCountAvailable
            {
                add
                {
                    base.Events.AddHandler(DataPagerRepeater.EventTotalRowCountAvailable, value);
                }
                remove
                {
                    base.Events.RemoveHandler(DataPagerRepeater.EventTotalRowCountAvailable, value);
                }
            }
    
            /// <summary>
            /// Register the control as one who's control state needs to be persisted
            /// </summary>
            /// <param name="e"></param>
            protected override void OnInit(EventArgs e)
            {
                base.OnInit(e);
                Page.RegisterRequiresControlState(this);
            }
    
            /// <summary>
            /// Initialize the start row index, maximum rows, and total rows available values.  Load the total rows available from viewstate.
            /// </summary>
            /// <param name="savedState"></param>
            protected override void LoadControlState(object savedState)
            {
                this.StartRowIndex = 0;
                this.MaximumRows = -1;
                this.TotalRowsAvailable = -1;
                object[] state = savedState as object[];
    
                if (state != null)
                {
                    base.LoadControlState(state[0]);
    
                    if (state[1] != null)
                    {
                        this.TotalRowsAvailable = (int)state[1];
                    }
    
                }
                else
                {
                    base.LoadControlState(null);
                }
    
                if (!IsViewStateEnabled)
                {
                    OnTotalRowCountAvailable(new PageEventArgs(this.StartRowIndex, this.MaximumRows, this.TotalRowsAvailable));
                }
            }
    
            /// <summary>
            /// Save the total rows available value to viewstate
            /// </summary>
            /// <returns></returns>
            protected override object SaveControlState()
            {
                object baseState = base.SaveControlState();
                if (baseState != null || this.TotalRowsAvailable != -1)
                {
                    object[] state = new object[2];
                    state[0] = baseState;
                    state[1] = this.TotalRowsAvailable;
                    return state;
                }
                return true;
            }
    
    
            /// <summary>Sets the properties of a page of data in the <see cref="T:InteriorHealth.Web.UI.WebControls.DataPagerRepeater" /> control.
            /// </summary>
            /// <param name="startRowIndex">The index of the first record on the page.</param>
            /// <param name="maximumRows">The maximum number of items on a single page.</param>
            /// <param name="databind">true to rebind the control after the properties are set; otherwise, false.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            ///   <paramref name="maximumRows" /> is less than 1.-or-<paramref name="startRowIndex" /> is less than 0.
            ///   </exception>
            public void SetPageProperties(int startRowIndex, int maximumRows, bool databind)
            {
                if (maximumRows < 1)
                {
                    throw new ArgumentOutOfRangeException("maximumRows");
                }
                if (startRowIndex < 0)
                {
                    throw new ArgumentOutOfRangeException("startRowIndex");
                }
                if (this.StartRowIndex != startRowIndex || this.StartRowIndex != maximumRows)
                {
                    PagePropertiesChangingEventArgs pagePropertiesChangingEventArgs = new PagePropertiesChangingEventArgs(startRowIndex, maximumRows);
                    if (databind)
                    {
                        this.OnPagePropertiesChanging(pagePropertiesChangingEventArgs);
                    }
    
                    this.StartRowIndex = pagePropertiesChangingEventArgs.StartRowIndex;
                    this.MaximumRows = pagePropertiesChangingEventArgs.MaximumRows;
    
                    if (databind)
                    {
                        this.OnPagePropertiesChanged(EventArgs.Empty);
                    }
                }
                if (databind)
                {
                    this.RequiresDataBinding = true;
                }
    
                //this.OnTotalRowCountAvailable(new PageEventArgs(this.StartRowIndex, this.MaximumRows, this.TotalRowsAvailable));
            }
    
    
            /// <summary>
            /// Creates a control hierarchy, with or without the specified data source.
            /// </summary>
            /// <param name="useDataSource">
            /// Indicates whether to use the specified data source. 
            /// </param>
            protected override void CreateControlHierarchy(bool useDataSource)
            {
                base.CreateControlHierarchy(useDataSource);
                OnTotalRowCountAvailable(new PageEventArgs(this.StartRowIndex, this.MaximumRows, this.TotalRowsAvailable));
            }
    
            /// <summary>Returns an <see cref="T:System.Collections.IEnumerable" /> interface from the data source.</summary>
            /// <returns>An object implementing <see cref="T:System.Collections.IEnumerable" /> that represents the data from the data source.</returns>
            protected override System.Collections.IEnumerable GetData()
            {
                System.Collections.IEnumerable data = base.GetData();
                this.TotalRowsAvailable = this.SelectArguments.TotalRowCount;
    
                this.OnTotalRowCountAvailable(new PageEventArgs(this.StartRowIndex, this.MaximumRows, this.TotalRowsAvailable));
                return data;
            }
    
            /// <summary>Raises the <see cref="E:InteriorHealth.Web.UI.WebControls.DataPagerRepeater.PagePropertiesChanging" /> event.
            /// </summary>
            /// <param name="e">The event data.</param>
            protected virtual void OnPagePropertiesChanging(PagePropertiesChangingEventArgs e)
            {
                EventHandler<PagePropertiesChangingEventArgs> eventHandler = (EventHandler<PagePropertiesChangingEventArgs>)base.Events[DataPagerRepeater.EventPagePropertiesChanging];
                if (eventHandler != null)
                {
                    eventHandler(this, e);
                }
            }
    
            /// <summary>Raises the <see cref="E:InteriorHealth.Web.UI.WebControls.DataPagerRepeater.SelectedIndexChanged" /> event.</summary>
            /// <param name="e">The event data.</param>
            protected virtual void OnPagePropertiesChanged(EventArgs e)
            {
                EventHandler eventHandler = (EventHandler)base.Events[DataPagerRepeater.EventPagePropertiesChanged];
                if (eventHandler != null)
                {
                    eventHandler(this, e);
                }
            } 
            
            /// <summary>Raises the <see cref="E:InteriorHealth.Web.UI.WebControls.DataPagerRepeater.PagePropertiesChanging" /> event.</summary>
            /// <param name="e">The event data.</param>
            protected virtual void OnTotalRowCountAvailable(PageEventArgs e)
            {
                EventHandler<PageEventArgs> eventHandler = (EventHandler<PageEventArgs>)base.Events[DataPagerRepeater.EventTotalRowCountAvailable];
                if (eventHandler != null)
                {
                    eventHandler(this, e);
                }
            }
    
    
            /// <summary>
            /// Override the selection of rows that we need
            /// </summary>
            /// <returns></returns>
            protected override DataSourceSelectArguments CreateDataSourceSelectArguments()
            {
                DataSourceSelectArguments arg = base.CreateDataSourceSelectArguments();
                arg.StartRowIndex = this.StartRowIndex;
                arg.MaximumRows = this.MaximumRows;
    
                return arg;
            }
        }
    }
