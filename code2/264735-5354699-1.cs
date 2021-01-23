    // in file WhateverYourClassIs.condition1.cs
    #if !CONDITION_1
    #error this file should never be included in a build WITHOUT CONDITION_1 set
    #endif
    public partial class WhateverYourClassIs {
        protected override void BeforeAdd(LogEntity entity) {
            entity.DateTimeInsert = DateTime.Now;
            base.BeforeAdd(entity);
        }
    }
    // in file WhateverYourClassIs.NotCondition1.cs
    #if CONDITION_1
    #error this file should never be included in a build WITH CONDITION_1 set
    #endif
    public partial class WhateverYourClassIs {
        protected override void BeforeAdd(AbstractBusinessEntity entity) {
            ((LogEntity)entity).DateTimeInsert = DateTime.Now;
            base.BeforeAdd(entity);
        }
    }
