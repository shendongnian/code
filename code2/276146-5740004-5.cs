    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Interop.ShDocVw;
    using mshtml;
    using Microsoft.Win32;
    using System.Windows.Forms;
    
    namespace InternetExplorerExtension
    {
        [ComVisible(true)]
        [ClassInterface(ClassInterfaceType.None)]
        [Guid("D40C654D-7C51-4EB3-95B2-1E23905C2A2D")]
        [ProgId("MyBHO.WordHighlighter")]
        public class WordHighlighterBHO : IObjectWithSite, IOleCommandTarget
        {
            const string DefaultTextToHighlight = "browser";
    
            IWebBrowser2 browser;
    
            #region Highlight Text
            void OnDocumentComplete(object pDisp, ref object URL)
            {
                var document = browser.Document as IHTMLDocument2;
    
                var window = document.parentWindow;
                window.execScript(@"function FncAddedByAddon() { alert('Message added by addon.'); }");
    
                Queue<IHTMLElement> queue = new Queue<IHTMLElement>();
                queue.Enqueue(document.body);
                while (queue.Count > 0)
                {
                    var el = queue.Dequeue();
                    // replacing desired text with a highlighted version of it
                    el.innerHTML = el.innerHTML.Replace(TextToHighlight, "<span style='background-color: yellow; cursor: hand;' onclick='javascript:FncAddedByAddon()' title='Click to open script based alert window.'>" + TextToHighlight + "</span>");
                    // adding children to collection
                    var x = (HTMLElementCollection)(el.children);
                    foreach (IHTMLElement eachChild in x)
                        queue.Enqueue(eachChild);
                }
            }
            #endregion
            #region Load and Save Data
            static string TextToHighlight = DefaultTextToHighlight;
            public static string RegData = "Software\\MyIEExtension";
            private static void SaveOptions()
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegData, true);
                if (registryKey == null)
                    registryKey = Registry.LocalMachine.CreateSubKey(RegData);
                registryKey.SetValue("Data", TextToHighlight);
                registryKey.Close();
            }
            private static void LoadOptions()
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegData, true);
                if (registryKey == null)
                    TextToHighlight = DefaultTextToHighlight;
                TextToHighlight = (string)registryKey.GetValue("Data");
                registryKey.Close();
            }
            #endregion
    
            #region Implementation of IObjectWithSite
            int IObjectWithSite.SetSite(object site)
            {
                if (site != null)
                {
                    LoadOptions();
                    browser = (IWebBrowser2)site;
                    ((DWebBrowserEvents2_Event)browser).DocumentComplete +=
                        new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                }
                else
                {
                    ((DWebBrowserEvents2_Event)browser).DocumentComplete -=
                        new DWebBrowserEvents2_DocumentCompleteEventHandler(this.OnDocumentComplete);
                    browser = null;
                }
                return 0;
            }
            int IObjectWithSite.GetSite(ref Guid guid, out IntPtr ppvSite)
            {
                IntPtr punk = Marshal.GetIUnknownForObject(browser);
                int hr = Marshal.QueryInterface(punk, ref guid, out ppvSite);
                Marshal.Release(punk);
                return hr;
            }
            #endregion
            #region Implementation of IOleCommandTarget
            int IOleCommandTarget.QueryStatus(IntPtr pguidCmdGroup, uint cCmds, ref OLECMD prgCmds, IntPtr pCmdText)
            {
                return 0;
            }
            int IOleCommandTarget.Exec(IntPtr pguidCmdGroup, uint nCmdID, uint nCmdexecopt, IntPtr pvaIn, IntPtr pvaOut)
            {
                var form = new HighlighterOptionsForm();
                form.InputText = TextToHighlight;
                if (form.ShowDialog() != DialogResult.Cancel)
                {
                    TextToHighlight = form.InputText;
                    SaveOptions();
                }
                return 0;
            }
            #endregion
    
            #region Registering with regasm
            public static string RegBHO = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Browser Helper Objects";
            public static string RegCmd = "Software\\Microsoft\\Internet Explorer\\Extensions";
    
            [ComRegisterFunction]
            public static void RegisterBHO(Type type)
            {
                string guid = type.GUID.ToString("B");
    
                // BHO
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegBHO, true);
                    if (registryKey == null)
                        registryKey = Registry.LocalMachine.CreateSubKey(RegBHO);
                    RegistryKey key = registryKey.OpenSubKey(guid);
                    if (key == null)
                        key = registryKey.CreateSubKey(guid);
                    key.SetValue("Alright", 1);
                    registryKey.Close();
                    key.Close();
                }
    
                // Command
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegCmd, true);
                    if (registryKey == null)
                        registryKey = Registry.LocalMachine.CreateSubKey(RegCmd);
                    RegistryKey key = registryKey.OpenSubKey(guid);
                    if (key == null)
                        key = registryKey.CreateSubKey(guid);
                    key.SetValue("ButtonText", "Highlighter options");
                    key.SetValue("CLSID", "{1FBA04EE-3024-11d2-8F1F-0000F87ABD16}");
                    key.SetValue("ClsidExtension", guid);
                    key.SetValue("Icon", "");
                    key.SetValue("HotIcon", "");
                    key.SetValue("Default Visible", "Yes");
                    key.SetValue("MenuText", "&Highlighter options");
                    key.SetValue("ToolTip", "Highlighter options");
                    //key.SetValue("KeyPath", "no");
                    registryKey.Close();
                    key.Close();
                }
            }
    
            [ComUnregisterFunction]
            public static void UnregisterBHO(Type type)
            {
                string guid = type.GUID.ToString("B");
                // BHO
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegBHO, true);
                    if (registryKey != null)
                        registryKey.DeleteSubKey(guid, false);
                }
                // Command
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(RegCmd, true);
                    if (registryKey != null)
                        registryKey.DeleteSubKey(guid, false);
                }
            }
            #endregion
        }
    }
