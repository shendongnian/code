    using Accessibility;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace ADDIProtocol
    {
    	publicclass IEAccessible
    	{
    		privateenum OBJID : uint
    		{
    			OBJID_WINDOW = 0x00000000,
    		}
    
    		privateconstint IE_ACTIVE_TAB = 2097154;
    		privateconstint CHILDID_SELF = 0;
    		private IAccessible accessible;
    
    		private IEAccessible[] Children
    		{
    			get
    			{
    				int num = 0;
    				object[] res = GetAccessibleChildren(accessible, out num);
    
    				if (res == null) returnnew IEAccessible[0];
    
    				List<IEAccessible> list = new List<IEAccessible>(res.Length);
    
    				foreach (object obj in res)
    				{
    					IAccessible acc = obj as IAccessible;
    
    					if (acc != null) list.Add(new IEAccessible(acc));
    				}
    
    				return list.ToArray();
    			}
    		}
    
    		privatestring Name
    		{
    			get
    			{
    				return accessible.get_accName(CHILDID_SELF);
    			}
    		}
    
    		privateint ChildCount
    		{
    			get
    			{
    				return accessible.accChildCount;
    			}
    		}
    
    		public IEAccessible()
    		{ }
    
    		public IEAccessible(IntPtr ieHandle, string tabCaptionToActivate)
    		{
    			int tabCount = GetTabCount(ieHandle);
    
    			if (tabCount > 0)
    			{
    				AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    				if (accessible == null) thrownew Exception();
    
    				IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
    
    				foreach (IEAccessible accessor in ieDirectUIHWND.Children)
    				{
    					foreach (IEAccessible child in accessor.Children)
    					{
    						foreach (IEAccessible tab  in child.Children)
    						{
    							if (tab.Name == tabCaptionToActivate)
    							{
    								tab.Activate();
    
    								return;
    							}
    						}
    					}
    				}
    			}
    		}
    
    		public IEAccessible(IntPtr ieHandle, int tabIndexToActivate)
    		{
    			AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    			if (accessible == null) thrownew Exception();
    
    			int index = 0;
    			IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
    
    			foreach (IEAccessible accessor in ieDirectUIHWND.Children)
    			{
    				foreach (IEAccessible child in accessor.Children)
    				{
    					foreach (IEAccessible tab in child.Children)
    					{
    						if (tabIndexToActivate >= child.ChildCount - 1) return;
    
    						if (index == tabIndexToActivate)
    						{
    							tab.Activate();
    
    							return;
    						}
    
    						index++;
    					}
    				}
    			}
    		}
    
    		private IEAccessible(IntPtr ieHandle)
    		{
    			AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    			if (accessible == null) thrownew Exception();
    		}
    
    		publicstring GetActiveTabUrl(IntPtr ieHandle)
    		{
    			AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    			if (accessible == null) thrownew Exception();
    
    			IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
    
    			foreach (IEAccessible accessor in ieDirectUIHWND.Children)
    			{
    				foreach (IEAccessible child in accessor.Children)
    				{
    					foreach (IEAccessible tab in child.Children)
    					{
    						object tabIndex = tab.accessible.get_accState(CHILDID_SELF);
    
    						if ((int)tabIndex == IE_ACTIVE_TAB)
    						{
    							string description = tab.accessible.get_accDescription(CHILDID_SELF);
    
    							if (!string.IsNullOrEmpty(description))
    							{
    								if (description.Contains(Environment.NewLine))
    								{
    									string url = description.Substring(description.IndexOf(Environment.NewLine)).Trim();
    
    									return url;
    								}
    							}
    						}
    					}
    				}
    			}
    
    			return String.Empty;
    		}
    
    		publicint GetActiveTabIndex(IntPtr ieHandle)
    		{
    			AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    			if (accessible == null) thrownew Exception();
    
    			int index = 0;
    			IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
    
    			foreach (IEAccessible accessor in ieDirectUIHWND.Children)
    			{
    				foreach (IEAccessible child in accessor.Children)
    				{
    					foreach (IEAccessible tab in child.Children)
    					{
    						object tabIndex = tab.accessible.get_accState(0);
    
    						if ((int)tabIndex == IE_ACTIVE_TAB) return index;
    
    						index++;
    					}
    				}
    			}
    
    			return -1;
    		}
    
    		publicstring GetActiveTabCaption(IntPtr ieHandle)
    		{
    			AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    			if (accessible == null) thrownew Exception();
    
    			IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
    
    			foreach (IEAccessible accessor in ieDirectUIHWND.Children)
    			{
    				foreach (IEAccessible child in accessor.Children)
    				{
    					foreach (IEAccessible tab in child.Children)
    					{
    						object tabIndex = tab.accessible.get_accState(0);
    
    
    						if ((int)tabIndex == IE_ACTIVE_TAB) return tab.Name;
    					}
    				}
    			}
    
    			return String.Empty;
    		}
    
    		public List<string> GetTabCaptions(IntPtr ieHandle)
    		{
    			AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    			if (accessible == null) thrownew Exception();
    
    			IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
    			List<string> captionList = new List<string>();
    
    			foreach (IEAccessible accessor in ieDirectUIHWND.Children)
    			{
    				foreach (IEAccessible child in accessor.Children)
    					foreach (IEAccessible tab in child.Children) captionList.Add(tab.Name);
    			}
    
    			if (captionList.Count > 0) captionList.RemoveAt(captionList.Count - 1);
    
    			return captionList;
    		}
    
    		publicint GetTabCount(IntPtr ieHandle)
    		{
    			AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
    
    			if (accessible == null) return 0; // throw new Exception();
    
    			IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
    
    			foreach (IEAccessible accessor in ieDirectUIHWND.Children)
    			{
    				foreach (IEAccessible child in accessor.Children)
    				{
    					foreach (IEAccessible tab in child.Children) return child.ChildCount - 1;
    				}
    			}
    
    			return 0;
    		}
    
    		private IntPtr GetDirectUIHWND(IntPtr ieFrame)
    		{
    			IntPtr directUI = FindWindowEx(ieFrame, IntPtr.Zero, "CommandBarClass", null);
    			directUI = FindWindowEx(directUI, IntPtr.Zero, "ReBarWindow32", null);
    			directUI = FindWindowEx(directUI, IntPtr.Zero, "TabBandClass", null);
    			directUI = FindWindowEx(directUI, IntPtr.Zero, "DirectUIHWND", null);
    
    			return directUI;
    		}
    
    		private IEAccessible(IAccessible acc)
    		{
    			if (acc == null) thrownew Exception();
    
    			accessible = acc;
    		}
    
    		privatevoid Activate()
    		{
    			accessible.accDoDefaultAction(CHILDID_SELF);
    		}
    
    		privatestaticobject[] GetAccessibleChildren(IAccessible ao, outint childs)
    		{
    			childs = 0;
    			object[] ret = null;
    			int count = ao.accChildCount;
    
    			if (count > 0)
    			{
    				ret = newobject[count];
    				AccessibleChildren(ao, 0, count, ret, out childs);
    			}
    
    			return ret;
    		}
    
    		#region Interop
    		[DllImport("user32.dll", SetLastError = true)]
    		privatestaticextern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
    
    		privatestaticint AccessibleObjectFromWindow(IntPtr hwnd, OBJID idObject, ref IAccessible acc)
    		{
    			Guid guid = new Guid("{618736e0-3c3d-11cf-810c-00aa00389b71}"); // IAccessibleobject obj = null;
    			int num = AccessibleObjectFromWindow(hwnd, (uint)idObject, ref guid, ref obj);
    
    			acc = (IAccessible)obj;
    
    			return num;
    		}
    
    		[DllImport("oleacc.dll")]
    		private static extern int AccessibleObjectFromWindow(IntPtr hwnd, uint id, ref Guid iid, [In, Out, MarshalAs(UnmanagedType.IUnknown)] refobject ppvObject);
    
    		[DllImport("oleacc.dll")]
    		private static extern int AccessibleChildren(IAccessible paccContainer, int iChildStart, int cChildren, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] object[] rgvarChildren, outint pcObtained);
    		#endregion
    	}
    }
