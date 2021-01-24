            var Violations = (from v in UnitOfWork.ViolationRepository.GetAll()
           join a in UnitOfWork.OneToManyRepository.GetAll().Where(a => a.ParentEntity == "Notice" && a.ChildEntity == "Violation")
          on v.ViolationId equals a.ChildEntityId
         join b in UnitOfWork.OneToManyRepository.GetAll().Where(a => a.ParentEntity == "Notice" && a.ChildEntity == "Case")
       on a.ParentId equals b.ParentId
      where b.ChildEntityId == caseId
      orderby v.ViolationId
      select v).ToList();
