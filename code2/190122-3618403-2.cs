	public interface IStackTagzContext {
		IQueryable<Question> Questions { get; }
		Question CreateQuestion();
		void CreateQuestion(Question question);
		void SaveChanges();
	}
	public class StackTagzContext : ObjectContext, IStackTagzContext {   
        public StackTagzContext() : base("name=myEntities", "myEntities")  
        {
			base.ContextOptions.LazyLoadingEnabled = true;
            m_Questions = CreateObjectSet<Question>();
        }
		#region IStackTagzContext Members
		private ObjectSet<Question> m_Questions;
		public IQueryable<Question> Questions {
            get { return m_Questions; }
        }
        
		public Question CreateQuestion() {
			return m_Questions.CreateObject();
		}
		public void AddQuestion(Question question) {
			m_Questions.AddeObject(question);
		}
		public new void SaveChanges() {
			base.SaveChanges();
		}
		#endregion
	}
