	using System;
	using System.Collections.Generic;
	
	using Android.App;
	using Android.Content;
	using Android.OS;
	using Android.Runtime;
	using Android.Views;
	using Android.Widget;
	
	namespace Scratch.ExpandableListActivity
	{
		[Activity (Label = "Scratch.ExpandableListActivity", MainLauncher = true)]
	    public class Activity1 : Android.App.ExpandableListActivity
	    {
	        IExpandableListAdapter mAdapter;
	        const string Name = "NAME";
	        const string IsEven = "IS_EVEN";
	
			protected override void OnCreate(Bundle bundle)
	        {
	            base.OnCreate(bundle);
				using (var groupData = new JavaList<IDictionary<string, object>> ())
				using (var childData = new JavaList<IList<IDictionary<string, object>>> ()) {
		            for (int i = 0; i < 20; i++) {
						using (var curGroupMap = new JavaDictionary<string, object>()) {
			                groupData.Add(curGroupMap);
			                curGroupMap.Add(Name, "Group " + i);
			                curGroupMap.Add(IsEven, (i % 2 == 0) ? "This group is even" : "This group is odd");
							using (var children = new JavaList<IDictionary<string, object>> ()) {
				                for ( int j = 0; j < 15; j++) {
									using (var curChildMap = new JavaDictionary<string, object> ()) {
					                    children.Add(curChildMap);
					                    curChildMap.Add(Name, "Child " + j);
					                    curChildMap.Add(IsEven, (j % 2 == 0) ? "This child is even" : "This child is odd");
									}
				                }
				                childData.Add(children);
							}
						}
		            }
		            // Set up our adapter
		            mAdapter = new SimpleExpandableListAdapter (
		                    this,
		                    groupData,
		                    Android.Resource.Layout.SimpleExpandableListItem1,
		                    new string[] { Name, IsEven},
		                    new int[] { Android.Resource.Id.Text1, Android.Resource.Id.Text2 },
		                    childData,
		                    Android.Resource.Layout.SimpleExpandableListItem2,
		                    new string[] { Name, IsEven },
		                    new int[] { Android.Resource.Id.Text1, Android.Resource.Id.Text2 }
		                    );
		            SetListAdapter(mAdapter);
				}
			}
		}
	}
	
