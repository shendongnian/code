    <script language="javascript" type="text/javascript">
         var TotalChkBx;
         var Counter;
         var TotalUnChkBx;
         var UnCounter;
         window.onload = function () {
             //Get total no. of CheckBoxes in side the GridView.
             TotalChkBx = parseInt('<%= this.GridView1.Rows.Count %>');
             //Get total no. of checked CheckBoxes in side the GridView.
             Counter = 0;
         }
         function HeaderClick(CheckBox) {
             //Get target base & child control.
             var TargetBaseControl = document.getElementById('<%= this.GridView1.ClientID %>');
             var TargetChildControl = "chkBxSelect";
             //Get all the control of the type INPUT in the base control.
             var Inputs = TargetBaseControl.getElementsByTagName("input");
             //Checked/Unchecked all the checkBoxes in side the GridView.
             for (var n = 0; n < Inputs.length; ++n)
                 if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                     Inputs[n].checked = CheckBox.checked;
             //Reset Counter
             Counter = CheckBox.checked ? TotalChkBx : 0;
         }
         function ChildClick(CheckBox, HCheckBox) {
             //get target base & child control.
             var HeaderCheckBox = document.getElementById(HCheckBox);
             //Modifiy Counter;            
             if (CheckBox.checked && Counter < TotalChkBx)
                 Counter++;
             else if (Counter > 0)
                 Counter--;
             //Change state of the header CheckBox.
             if (Counter < TotalChkBx)
                 HeaderCheckBox.checked = false;
             else if (Counter == TotalChkBx)
                 HeaderCheckBox.checked = true;
         }
    </script>
