	public interface IJTokenWorker
	{
		bool ProcessToken<TConvertible>(JContainer parent, TConvertible index, JToken current, int depth) where TConvertible : IConvertible;
	}
	public static partial class JsonExtensions
	{
		public static void WalkTokens(this JToken root, IJTokenWorker worker, bool includeSelf = false)
		{
			if (worker == null)
				throw new ArgumentNullException();
			DoWalkTokens<int>(null, -1, root, worker, 0, includeSelf);
		}
		static void DoWalkTokens<TConvertible>(JContainer parent, TConvertible index, JToken current, IJTokenWorker worker, int depth, bool includeSelf) where TConvertible : IConvertible
		{
			if (current == null)
				return;
			if (includeSelf)
			{
				if (!worker.ProcessToken(parent, index, current, depth))
					return;
			}
			var currentAsContainer = current as JContainer;
			if (currentAsContainer != null)
			{
				IList<JToken> currentAsList = currentAsContainer; // JContainer implements IList<JToken> explicitly
				for (int i = 0; i < currentAsList.Count; i++)
				{
					var child = currentAsList[i];
					if (child is JProperty)
					{
						DoWalkTokens(currentAsContainer, ((JProperty)child).Name, ((JProperty)child).Value, worker, depth+1, true);
					}
					else
					{
						DoWalkTokens(currentAsContainer, i, child, worker, depth+1, true);
					}
				}
			}
		}
	}
