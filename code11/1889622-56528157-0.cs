lang-csharp
private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
{
   if (DataIsDirty())
   {
      if (MessageBox.Show(
            "Unsaved changes detected. Press OK to switch nodes and lose the change, or Cancel to stay on the current node.",
            "Unsaved Changes Detected",
            MessageBoxButtons.OKCancel) == DialogResult.Cancel)
      {
          e.Cancel = true;
      }
   }
}
