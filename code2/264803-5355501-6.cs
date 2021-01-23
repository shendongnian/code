        Node current = head;
        for (int i = 1; i < size; i++)
        {
            for (int j = 0; j < size - 1; j++)
            {
                if (current.Data > current.Next.Data && current.Next!=null)
                {
                    int temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                }
            }
        }
