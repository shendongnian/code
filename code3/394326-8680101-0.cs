    using System;
    using Android.App;
    using Android.Content;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    using System.Collections.Generic;
    namespace MonoAndroidApplication2
    {
    	[Activity(Label = "Expandable List Activity", MainLauncher = true )]
    	public class Activity1 : ExpandableListActivity
    	{
    		IExpandableListAdapter mAdapter;
    		String NAME = "NAME";
    		String IS_EVEN = "IS_EVEN";
    		protected override void OnCreate(Bundle bundle)
    		{
    			base.OnCreate(bundle);
    			List< IDictionary <String , object >> groupData = new List< IDictionary < string , object >>();
    			List< IList<IDictionary< String, object>>> childData = new List < IList < IDictionary < string, object>>>();
    			for ( int i = 0; i < 20; i++)
    			{
    				Dictionary< String, object > curGroupMap = new Dictionary < string , object >();
    				groupData.Add(curGroupMap);
    				curGroupMap.Add(NAME, "Group " + i);
    				curGroupMap.Add(IS_EVEN, (i % 2 == 0) ? "This group is even" : "This group is odd");
    				List< IDictionary <String , object >> children = new List< IDictionary < string , object >>();
    				for ( int j = 0; j < 15; j++)
    				{
    					Dictionary< String, object > curChildMap = new Dictionary < string , object >();
    					children.Add(curChildMap);
    					curChildMap.Add(NAME, "Child " + j);
    					curChildMap.Add(IS_EVEN, (j % 2 == 0) ? "This child is even" : "This child is odd");
    				}
    				childData.Add(children);
    			}
    			// Set up our adapter
    			mAdapter = new SimpleExpandableListAdapter (
    					this,
    					groupData,
    					Android.Resource.Layout.SimpleExpandableListItem1,
    					new String[] { NAME, IS_EVEN },
    					new int[] { Android.Resource.Id.Text1, Android.Resource.Id.Text2 },
    					childData,
    					Android. Resource. Layout.SimpleExpandableListItem2,
    					new String[] { NAME, IS_EVEN },
    					new int[] { Android.Resource .Id.Text1, Android.Resource.Id.Text2 }
    					);
    			SetListAdapter(mAdapter);
    		}
    	}
    }
