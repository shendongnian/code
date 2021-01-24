public int CompareTo(QueueEntryElement obj)
        {
            if (obj == null) return 1;
            QueueEntryElement otherQueueEntryElement = obj as QueueEntryElement;
            if (otherQueueEntryElement != null)
            {
                if (Priority.CompareTo(otherQueueEntryElement.Priority) == 0)
                {
                    return OrderId.CompareTo(otherQueueEntryElement.OrderId);
                }
                return 0;
            }
            else
                throw new ArgumentException("Object is not a QueueEntryElement");
        }
