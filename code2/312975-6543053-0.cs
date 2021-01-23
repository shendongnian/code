    public ActionResult ProfessorStatus(string schoolType) {
      Expresison<Func<Professor, bool>> filter;
      switch (schoolType) {
        case "Engineering":
          filter= a => a.Engineering.Value == true;
          break;
        default:
          throw new Exception("Unknown SchoolType - " + schoolType);
      }
      var activeProfessors = (from p in prof.ProfessorTable.Where(filter)
         group p by p.ProfessorID into g
         select g.Key).ToList();
      return View(activeProfessors);
    }
