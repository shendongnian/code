    Project p;
    List<Projects> projectList = new List() {
        p = new Project() { 
            id = 100500
        ,   Subprojects = new List<Subproject>()
        }
    };
    p.Subprojects.Add(
        new Subproject { Project = p }
    );
