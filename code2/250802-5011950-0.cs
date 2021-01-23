    private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
    {
        var filteredValues = new List<string>();
        var criteria = gridColumn1.FilterInfo.FilterCriteria;
        if (criteria is GroupOperator)
        {
            var group = (GroupOperator)criteria;
            foreach (var operand in group.Operands.OfType<BinaryOperator>())
            {
                var value = (OperandValue)operand.RightOperand;
                filteredValues.Add(value.Value.ToString());
            }
        }
        else if(criteria is BinaryOperator)
        {
            var value = (OperandValue)((BinaryOperator)criteria).RightOperand;
            filteredValues.Add(value.Value.ToString());
        }
        // Do something with the filtered values
    }
