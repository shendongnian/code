        public override int GetMovementFlags(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder)
        {
            if (viewHolder.AdapterPosition == 10)
            {
                return 0;
            }
            if(viewHolder.AdapterPosition==mdapter.selectionposition)
            {
                return 0;
            }
            return base.GetMovementFlags(recyclerView, viewHolder);
        }
