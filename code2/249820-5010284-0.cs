    ManagerDropDownList.value = IdValuePassedToForm;
    for (var i = 0; i < TeamCheckBoxes.length; i++)
    {
        if (TeamMembersPassedToForm.Contains(TeamCheckBoxes[i].value))
        {
            TeamCheckBoxes[i].checked = true;
        }
    }
