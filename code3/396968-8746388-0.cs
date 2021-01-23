            String text = "SMITH 9-2 #3-10H13";
            String[] values = text.Split(' ');
            String v = values[1];
            String[] numbers = v.Split('-');
            String newValue = numbers[0].PadLeft(2, '0') + '-' + numbers[1].PadLeft(2, '0');
            String newText = text.Replace(" " + values[1] + " ", " " + newValue + " ");
