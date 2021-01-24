         protected void BeefCB_CheckedChanged(object sender, EventArgs e)
         {
               SupplierProduceType();
         }
         protected void PorkCB_CheckedChanged(object sender, EventArgs e)
         {
               SupplierProduceType();
         }
         protected void ChickenCB_CheckedChanged(object sender, EventArgs e)
         {
               SupplierProduceType();
         }
         protected void LambCB_CheckedChanged(object sender, EventArgs e)
         {
               SupplierProduceType();
         }
         protected void SauceCB_CheckedChanged(object sender, EventArgs e)
         {
               SupplierProduceType();
         }
    
         private void SupplierProduceType()
         {
               string produceType = string.Empty;
               if(BeefCB.Checked)
               {
                   produceType = "Beef, ";
               }
               if(PorkCB_Checked)
               {
                   produceType += "Pork, ";
               }
               if(ChickenCB_Checked)
               {
                   produceType += "Chicken, ";
               }
               if(LambCB_Checked)
               {
                   produceType += "Lamb, ";
               }
               if(SauceCB_Checked)
               {
                   produceType += "Sauce, ";
               }
               SupplierProduceTypeTB.Text = produceType;
        }
