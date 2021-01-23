    namespace WordTestAddin
    {
        public partial class ThisAddIn
        {
            private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
              Type ty = this.Application.GetType().GetEvent("DocumentBeforeClose").EventHandlerType;
              var testDelegate = Delegate.CreateDelegate(ty, this, "test", false);
              this.Application.GetType().GetEvent("DocumentBeforeClose").AddEventHandler(this.Application, testDelegate);
            }
            void test(Word.Document Doc, ref bool Cancel)
            {
              System.Windows.Forms.MessageBox.Show("test");
            }
            private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
            {
            }
            #region VSTO generated code
            private void InternalStartup()
            {
              this.Startup += new System.EventHandler(ThisAddIn_Startup);
              this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
            }
        
            #endregion
        }
    }
