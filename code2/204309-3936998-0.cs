	[Test]
	public void Should_get_computed_table_0_0_0_0_1_2_given_ABCDABD()
	{
		const string input = "ABCDABD";
		var result = BuildTable(input);
		result.Length.ShouldBeEqualTo(input.Length);
		result[0].ShouldBeEqualTo(-1);
		result[1].ShouldBeEqualTo(0);
		result[2].ShouldBeEqualTo(0);
		result[3].ShouldBeEqualTo(0);
		result[4].ShouldBeEqualTo(0);
		result[5].ShouldBeEqualTo(1);
		result[6].ShouldBeEqualTo(2);
	}
	[Test]
	public void Should_get_computed_table_0_1_2_3_4_5_given_AAAAAAA()
	{
		const string input = "AAAAAAA";
		var result = BuildTable(input);
		result.Length.ShouldBeEqualTo(input.Length);
		result[0].ShouldBeEqualTo(-1);
		result[1].ShouldBeEqualTo(0);
		result[2].ShouldBeEqualTo(1);
		result[3].ShouldBeEqualTo(2);
		result[4].ShouldBeEqualTo(3);
		result[5].ShouldBeEqualTo(4);
		result[6].ShouldBeEqualTo(5);
	}
