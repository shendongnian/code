    <script type="text/javascript">
        function Check_All(ChkBoxHeader)
        {
            //First Access the GridView Control
            var gridview = document.getElementById('<%=GridEmployees.ClientID %>');
            
            //Now get the all the Input type elements in the GridView
            var AllInputsElements = gridview.getElementsByTagName('input');
            var TotalInputs = AllInputsElements.length;
            //Now we have to find the checkboxes in the rows.
            for(var i=0;i< TotalInputs ; i++ )
            {
                if(AllInputsElements[i].type =='checkbox')
                {
                    AllInputsElements[i].checked = ChkBoxHeader.checked;
                }
            }
            
        }
