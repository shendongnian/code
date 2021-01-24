    public IActionResult ShowSelectedMembers(MembersViewModel vm)
    {
        ModelState.Clear();
        vm.Members = vm.Members.Where(s => s.Selected).OrderBy(o => o.LastName).ThenBy(o => o.FirstName).ToList();
        return View(vm);
    }
