	public class ModifiedCollection : BindingSource {
		BindingSource Source {get;set;}
		BindingManagerBase bmb;
		Control Parent;
		public ModifiedCollection(object Source, Control Parent) {
			if ((this.Source = Source as BindingSource) == null) {
				this.Source = new BindingSource();
				this.Source.DataSource = Source;
			}
			this.Source.ListChanged += new ListChangedEventHandler(Source_ListChanged);
			
			this.Parent = Parent;
			this.Parent.BindingContextChanged += new EventHandler(Parent_BindingContextChanged);
		}
		void Parent_BindingContextChanged(object sender, EventArgs e) {
			if (bmb != null) {
				bmb.PositionChanged -= bmb_PositionChanged;
			}
			if (Parent.FindForm().BindingContext.Contains(this.Source.DataSource)) {
				bmb = Parent.BindingContext[this.Source.DataSource];
				if (bmb != null) {
					bmb.PositionChanged += new EventHandler(bmb_PositionChanged);
				}
			}
		}
	}
