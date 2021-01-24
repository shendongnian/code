    @if (registerModel.MemberProperties != null)
            {
                // first property
                @Html.LabelFor(m => registerModel.MemberProperties[0].Value, registerModel.MemberProperties[0].Name)
                    
                @Html.EditorFor(m => registerModel.MemberProperties[0].Value)
                @Html.HiddenFor(m => registerModel.MemberProperties[0].Alias)
                <br />
               
                // second property
                @Html.LabelFor(m => registerModel.MemberProperties[1].Value, registerModel.MemberProperties[1].Name)
                    
                @Html.EditorFor(m => registerModel.MemberProperties[1].Value)
                @Html.HiddenFor(m => registerModel.MemberProperties[1].Alias)
                <br />
                // ... and so on for all the other MemberProperties defined in my MemberType
                }
            }
