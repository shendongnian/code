    public IQueryable<BvIndexRow> GetBenefitVariableIndex(int healthPlanId)
    {
       var q =    ... your query ...
          select new BvIndexRow
          {
             Type = (bv.Private.ToLower() == "y" ? "Private " : "Public ") + (bao.ba_system_variable_ind ? "System" : "Benefit"),
             Class = bv.Variable_Classification,
             ServiceType = bvst.Service_Type.Service_Type_Name ?? string.Empty,
             LineOfBusiness = bv.LOB,
             Status = bv.Status.ToLower() == "p" ? "Production" : "Test",
             Name = bao.ba_object_Code,
             Description = bao.ba_Object_Desc,
             Id = bv.Variable_Id,
          };
       foreach (var bvIndexRow in q) {
          bvIndexRow.ValidCodes = GetValidCodes(bvIndexRow .Variable_Id);
       }
    
       return q;
       }
