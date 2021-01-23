	public class ARExpandableListAdapter : BaseExpandableListAdapter
	{
		private Context context;
		private IList<string> groups;
		private IList<IAccountsReceivable> children;
		
		public ARExpandableListAdapter(Context context, IList<string> groups, IList<IAccountsReceivable> children)
		{
			this.context = context;
			this.groups = groups;
			this.children = children;
		} 
		#region implemented abstract members of Android.Widget.BaseExpandableListAdapter
		public override Java.Lang.Object GetChild (int groupPosition, int childPosition)
		{
			
			return (Java.Lang.Object)children[groupPosition]; //as Java.Lang.Object.JavaCast<decimal>();
		}
		public override long GetChildId (int groupPosition, int childPosition)
		{
			return childPosition;
		}
		public override View GetChildView (int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{
			if(convertView == null)
			{
				LayoutInflater infaInflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
				convertView = infaInflater.Inflate(Resource.Layout.child_layout, null);
			}
			
			if(childPosition<6)
			{
				string label = " ";
				if (childPosition == 0)
					label = children[groupPosition].TransactionType;
				if (childPosition == 1)
					label = children[groupPosition].TransactionValue.ToString();
				if (childPosition == 2)
					label = children[groupPosition].TransactionDate.ToString();
				if (childPosition == 3)
					label = children[groupPosition].TransactionDueDate.ToString();
				if (childPosition == 4)
					label = children[groupPosition].OrderNumber.ToString();
				if (childPosition == 5)
					label = children[groupPosition].CustomerReference;
				
				
			TextView tv = (TextView) convertView.FindViewById(Resource.Id.tvChild);
			tv.SetText(" " + label, TextView.BufferType.Normal);
			}
			return convertView;
		}
		public override int GetChildrenCount (int groupPosition)
		{
			return children.Count;
		}
		public override Java.Lang.Object GetGroup (int groupPosition)
		{
			return groups[groupPosition];
		}
		public override long GetGroupId (int groupPosition)
		{
			return groupPosition;
		}
		public override View GetGroupView (int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			string _group = (string)GetGroup(groupPosition);
			if(convertView==null)
			{
				LayoutInflater infalInflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
				convertView = infalInflater.Inflate(Resource.Layout.group_layout, null);
			}
			TextView tv = (TextView)convertView.FindViewById(Resource.Id.tvGroup);
			tv.SetText(_group, TextView.BufferType.Normal);
			return convertView;
		}
		public override bool IsChildSelectable (int groupPosition, int childPosition)
		{
			return true;
		}
		public override int GroupCount {
			get {
				return groups.Count();
			}
		}
		public override bool HasStableIds {
			get {
				return true;
			}
		}
		#endregion
	
	}
