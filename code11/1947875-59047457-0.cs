    public void InitProjects(Button btnSelectProject)
    {
        if (_btnSelecteProj != null)
        {
            if (_btnSelecteProj.Equals(btnSelectProject))
                return;
            _btnSelecteProj.MouseClick -= BtnSelecteProj_MouseClick;
        }
        _btnSelecteProj = btnSelectProject;
        _btnSelecteProj.MouseClick += BtnSelecteProj_MouseClick;
    }
