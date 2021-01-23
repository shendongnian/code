    modified = context.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
                    if (modified != null && modified.Count() > 0)
                    {
                        foreach (ObjectStateEntry ose in modified)
                        {
                            if (
                                (ose.Entity.GetType() == typeof(CommissionPlanCustomer) && ((CommissionPlanCustomer)ose.Entity).CommissionPlan == null)
                                ||
                                (ose.Entity.GetType() == typeof(CommissionPlanItemEligibleUser) && ((CommissionPlanItemEligibleUser)ose.Entity).CommissionPlanItem == null)
                                ||
                                (ose.Entity.GetType() == typeof(CommissionPlanItem) && ((CommissionPlanItem)ose.Entity).CommissionPlan == null)
                               )
                            {
                                context.DeleteObject(ose.Entity);
                            }
                        }
                    }
