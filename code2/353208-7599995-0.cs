    public IEnumerable<Fact> Facts
            {
                get
                {
                    ...
                }
                set
                {
                    ValidateReceived(value);
                    ExtractFactTypesFrom(value.ToList());
                }
            }
    
            protected virtual void ValidateReceived(IEnumerable<Fact> factTypes)
            {
                if (factTypes == null) throw new ArgumentNullException("factTypes");
    
                var allowedTypes = GetAllowedFactTypes();
                if (!factTypes.All(rootFact => allowedTypes.Contains(rootFact.GetType()))) throw new Exception("DataWarehouseFacts can only be set with root facts");
            }
    
            private IEnumerable<Type> GetAllowedFactTypes()
            {
                var allowedTypes = new[]
                {
                    typeof (ProductUnitFact), 
                    typeof (SequenceRunFact), 
                    typeof (FailureFact), 
                    typeof (DefectFact),
                    typeof (ProcessRunFact), 
                    typeof (CustomerFact), 
                    typeof (ProductUnitReturnFact),
                    typeof (ShipmentFact), 
                    typeof (EventFact), 
                    typeof (ComponentUnitFact), 
                    typeof (SourceDetails)
                };
    
                return allowedTypes;
            }
    
            private void ExtractFactTypesFrom(List<Fact> value)
            {
                ProductUnitFacts = value.OfType<ProductUnitFact>().ToList();
                FailureFacts = value.OfType<FailureFact>().ToList();
                DefectFacts = value.OfType<DefectFact>().ToList();
                ProcessRunFacts = value.OfType<ProcessRunFact>().ToList();
                SequenceRunFacts = value.OfType<SequenceRunFact>().ToList();
                CustomerFacts = value.OfType<CustomerFact>().ToList();
                ProductUnitReturnFacts = value.OfType<ProductUnitReturnFact>().ToList();
                ShipmentFacts = value.OfType<ShipmentFact>().ToList();
                EventFacts = value.OfType<EventFact>().ToList();
                ComponentUnitFacts = value.OfType<ComponentUnitFact>().ToList();
                SourceDetails = value.OfType<SourceDetails>().Single();
            }
