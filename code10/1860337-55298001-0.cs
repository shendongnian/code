    List<Assignment> assignmentList;
    					if (!string.IsNullOrWhiteSpace(bookingStep.FilterPropertyName) &&
    					    !string.IsNullOrWhiteSpace(bookingStep.FilterPropertyValue))
    					{
    						assignmentList = await
    							assignmentListQuery.Where(e =>
    								EF.Property<string>(e, bookingStep.FilterPropertyName) ==
    								bookingStep.FilterPropertyValue).ToListAsync();
    					}
    					else
    					{
    						assignmentList = await assignmentListQuery.ToListAsync();
    					}
