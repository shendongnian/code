    public class DivergencesResolver : ValueResolver<MyClass, int>
    {
        private AssessmentService assessmentService;
    
        public DivergencesResolver(AssessmentService assessmentService)
        {
            this.assessmentService = assessmentService;
        }
    
        protected override int ResolveCore(MyClass c)
        {
            return assessmentService.GetAssessmentDivergences(c.AssessmentId).Count();
        }
    }
