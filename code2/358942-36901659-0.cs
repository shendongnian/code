        private string CreateWhereClause(Expression<Func<T, bool>> predicate)
		{
			StringBuilder p = new StringBuilder(predicate.Body.ToString());
			var pName = predicate.Parameters.First();
			p.Replace(pName.Name + ".", "");
			p.Replace("==", "=");
			p.Replace("AndAlso", "and");
			p.Replace("OrElse", "or");
			p.Replace("\"", "\'");
			return p.ToString();
		}
		private string AddWhereToSelectCommand(Expression<Func<T, bool>> predicate, int maxCount = 0)
		{			
			string command = string.Format("{0} where {1}", CreateSelectCommand(maxCount), CreateWhereClause(predicate));
			return command;
		}
		private string CreateSelectCommand(int maxCount = 0)
		{
			string selectMax = maxCount > 0 ? "TOP " + maxCount.ToString() + " * " : "*";
			string command = string.Format("Select {0} from {1}", selectMax, _tableName);
			return command;
		}
