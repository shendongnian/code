    <div class="row">
    	@foreach(StudentCohortViewModel studentCohort in ViewBag.CohortSubscriptionId)
    	{
    		if (studentCohort.ContractStatus == "Pending")
    		{
    			<text>
    				@studentCohort.FullName (@Html.ActionLink(studentCohort.ContractStatus,
                                                   "Edit",
                                                   "CohortSubscriptions",
    				                               new { id = student.ContractStatus },
    											   new { @class = "form-control" }))
    			</text>
    		}
    		else
    		{
    			<text>
    				@studentCohort.FullName (@studentCohort.ContractStatus)
    			</text>
    		}
    	}
    </div>
