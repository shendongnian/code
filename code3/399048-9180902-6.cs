    public class VeryGeneralDefaultRuleAboutAllObjects : IRule<IMyClass>
    {
        private readonly Context _context;
        public VeryGeneralDefaultRuleAboutAllObjects(Context context){
            _context = context;    
        }
        public bool IsValid(IMyClass obj){
            return !obj.IsAllJackedUp;
        }
        public bool WithinScope(){
            return !_context.IsSpecialCase;
        }
    }
    public class SpecificCaseWhenGeneralRuleDoesNotApply : IRule<IMyClass>
    {
        private readonly Context _context;
        public VeryGeneralDefaultRuleAboutAllObjects(Context context){
            _context = context;    
        }
        public bool IsValid(IMyClass obj){
            return !obj.IsAllJackedUp && _context.HasMoreCowbell;
        }
        public bool WithinScope(){
            return _context.IsSpecialCase;
        }
    }
