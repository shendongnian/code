        public class BillableUnbillableEdit : IValidatableObject
        {
            public int WorkOrderId { get; set; }
            [Required]
            public string Title { get; set; }
            public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                //TODO: any other validation before changing and saving this record?
                var db = new WorkorderEntities();
                if (db.WorkOrders.Any(i => i.Title == Title && i.Id != WorkOrderId))
                    yield return new ValidationResult($"A WorkOrder with the same title already exists.", new[] { "Title" });
            }
        }
