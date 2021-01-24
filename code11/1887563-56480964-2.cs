    @if (registerModel.MemberProperties != null)
            {
                for (var i = 0; i < registerModel.MemberProperties.Count; i++)
                {
                    @Html.LabelFor(m => registerModel.MemberProperties[i].Value, registerModel.MemberProperties[i].Name)
                    
                    @Html.EditorFor(m => registerModel.MemberProperties[i].Value)
                    @Html.HiddenFor(m => registerModel.MemberProperties[i].Alias)
                    <br />
                }
            }
