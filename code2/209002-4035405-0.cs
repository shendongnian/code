      private void tableMeLikeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
      {
         try
         {
            this.Validate();
            this.tableMeLikeBindingSource.EndEdit();
            
            // IMPORTANT: the following predefined generic Update command
            // does NOT work (sometimes)
            // this.tableAdapterManager.UpdateAll(this.rESOURCE_DB_1DataSet);
            // instead we explicitely points out the right table adapter and updates
            // only the table of interest...
            this.tableMeLikeTableAdapter.Update(this.rESOURCE_DB_1DataSet.TableMeLike);
         }
         catch (Exception ex)
         {
            myExceptionHandler.HandleExceptions(ex);
         }
      }
