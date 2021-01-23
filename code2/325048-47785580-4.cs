    public void CancelTask(int id)
            {
                if (interactionCache.ContainsKey(id))
                {
                    List<Tuple<int, int>> list;
                    interactionCache.Remove(id, out list);
                }
                if (tasks.ContainsKey(id) && tasks[id] != null)
                {
                    tasks[id].Cancel();
                }
            }
